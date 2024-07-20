import { useEffect, useState } from 'react';
import CardSlider from '../components/Card/CardSlider';
import { HiSearch } from 'react-icons/hi';
import { MdAddToPhotos } from 'react-icons/md';
import Modal from '../components/Modal/Modal';
import { useFetchAllImagesByPages } from '../utils/queries';
import StaticBrands from '../components/Domain/StaticBrands';

const Brands = () => {
    const { mutateAsync: fetchAllImagesMutation, isLoading: isLoadingAllImages } = useFetchAllImagesByPages();

    const [brandsData, setBrandsData] = useState([]);
    const [pageAt, setPageAt] = useState(1);
    const [numberOfPages, setNumberOfPages] = useState(10);
    const [printableBtns, setPrintableBtns] = useState([0]);
    const [brandWanted, setBrandWanted] = useState(null);

    useEffect(() => {
        imageDataSetup();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [pageAt]);

    const imageDataSetup = async () => {
        var data = await fetchAllImagesMutation({
            pageAt: pageAt,
            filteredBrand: brandWanted
        });
        setNumberOfPages(data.totalPages);
        setBrandsData(data.data);
        createPrintableBtns();
    }

    const createPrintableBtns = () => {
        const startNumber = Math.max(1, Math.floor((pageAt - 1) / 10) * 10 + 1);
        const endNumber = Math.min(startNumber + 9, numberOfPages);

        const buttonsArray = Array.from({ length: endNumber - startNumber + 1 }, (_, index) => startNumber + index);
        
        setPrintableBtns(buttonsArray);
    }

    const handleSelectChange = (e) => {
        setBrandWanted(e.target.value);
    };

    return (
        <div className="container-fluid pt-5">
            <div className="row gx-5">
                <div className="d-flex flex-row col-md-2" data-bs-theme="dark">
                    <select className="form-select" id="validationCustom04" onChange={handleSelectChange}>
                        {
                            StaticBrands.map(brandElem => 
                                {
                                    return <option key={brandElem.id} value={brandElem.name}>{brandElem.name}</option>;
                                }
                            )
                        }
                    </select>
                    <button type="button" className="btn btn-light ml-2" onClick={() => setPageAt(1)}><HiSearch size={25}/></button>
                </div>
            </div>
            <CardSlider Brands={brandsData} pageAt={pageAt} alterPage={setPageAt} printableBtns={printableBtns} maxNumberOfPages={numberOfPages}/>
            <Modal teste={"ok ok ok"}/>
            {
                isLoadingAllImages &&
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

export default Brands
