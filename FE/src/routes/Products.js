import { useEffect, useState } from 'react';
import CardSlider from '../components/Card/CardSlider';
import { HiSearch } from 'react-icons/hi';
import { 
    useFetchAllProductsByPages,
    useGetUserByCredentialsMutation,
    useUpdateFiltersForUserMutation
} from '../utils/queries';

const Products = () => {
    const { mutateAsync: fetchAllProductsMutation, isLoading: isLoadingAllProducts } = useFetchAllProductsByPages();
    const { mutateAsync: getUserByCredentialsMutation, isLoading: isLoadingAllUserCredentials } = useGetUserByCredentialsMutation();
    const { mutateAsync: updateFiltersForUserMutation, isLoading: isLoadingAllUpdatedFilters } = useUpdateFiltersForUserMutation();

    const [userData, setUserData] = useState(null);
    const [formElements, setFormElements] = useState({
        nameFilter: "",
        productCategoryFilter: ""
    });
    const [ProductsData, setProductsData] = useState([]);
    const [pageAt, setPageAt] = useState(1);
    const [newRequest, setNewRequest] = useState(1);
    const [numberOfPages, setNumberOfPages] = useState(0);
    const [printableBtns, setPrintableBtns] = useState([0]);

    useEffect(() => {
        imageDataSetup();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [pageAt,newRequest]);

    const imageDataSetup = async () => {
        var user = await getUserByCredentialsMutation();

        setFormElements({
            nameFilter: user.nameFilter != null  ? user.nameFilter.allPreviousSearched.join(" ") : "",
            productCategoryFilter: user.productCategoryFilter != null ? user.productCategoryFilter.allPreviousSearched.join(" ") : ""
        });
            
        setUserData(user);
        var data = await fetchAllProductsMutation({
            pageAt: pageAt,
            nameFilter: user.nameFilter,
            productCategoryFilter: user.productCategoryFilter
        });
        setNumberOfPages(data.totalPages);
        setProductsData(data.products);
        createPrintableBtns();
    }

    const createPrintableBtns = () => {
        const startNumber = Math.max(1, Math.floor((pageAt - 1) / 10) * 10 + 1);
        const endNumber = Math.min(startNumber + 9, numberOfPages);

        const buttonsArray = Array.from({ length: endNumber - startNumber + 1 }, (_, index) => startNumber + index);
        
        setPrintableBtns(buttonsArray);
    }

    const updateUserFilters = async () => {
        var nameFilter = formElements.nameFilter.split(" ");
        var productCategoryFilter = formElements.productCategoryFilter.split(" ");
        await updateFiltersForUserMutation({
            nameFilter: {
                allPreviousSearched: nameFilter
            },
            productCategoryFilter: {
                allPreviousSearched: productCategoryFilter
            }
        })
        setNewRequest(oldValue => {
            return oldValue++;
        });
    }

    return (
        <div className="container-fluid pt-5">
            <div className="row gx-5">
                <div className="d-flex flex-row col-md-6" data-bs-theme="dark">
                    <textarea class="form-control" placeholder="name filter" rows="3" onInput={(e) => setFormElements({...formElements, nameFilter: e.target.value})}>{formElements.nameFilter}</textarea>
                    <textarea class="form-control" placeholder="product category" rows="3" onInput={(e) => setFormElements({...formElements, productCategoryFilter: e.target.value})}>{formElements.productCategoryFilter}</textarea>
                    <button type="button" className="btn btn-light ml-2" onClick={() => updateUserFilters()}><HiSearch size={25}/></button>
                </div>
            </div>
            <CardSlider Products={ProductsData} pageAt={pageAt} alterPage={setPageAt} printableBtns={printableBtns} maxNumberOfPages={numberOfPages}/>
            {
                isLoadingAllProducts &&
                <div class="overlay">
                    <div class="text-center">
                        <div class="spinner-border" style={{width: "3rem", height: "3rem"}} role="status">
                            <span class="sr-only"></span>
                        </div>
                    </div>
                </div>
            }
        </div>
    )
}

export default Products
