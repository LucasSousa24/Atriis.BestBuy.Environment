import Card from './Card';
import CardPagination from './CardPagination';

const CardSlider = ({Products, pageAt, alterPage, printableBtns, maxNumberOfPages}) => {
    return (
        <div className="container-fluid mt-5">
            <div className={`row row-cols-6`}>
                {
                    Products.length > 0 &&
                    Products.map((product, index) => {
                        return (
                            <div className="col-lg-2 d-flex align-items-stretch">
                                <Card 
                                    key={index}
                                    product={product}
                                />
                            </div>
                        );
                    })
                }
            </div>
            <div className="d-flex justify-content-center mt-3 mb-3">
                <CardPagination printableBtns={printableBtns} pageAt={pageAt} alterPage={alterPage} maxNumberOfPages={maxNumberOfPages}/>
            </div>
        </div>
    );
}

export default CardSlider