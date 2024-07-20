import Card from './Card';
import CardPagination from './CardPagination';

const CardSlider = ({Brands, pageAt, alterPage, printableBtns, maxNumberOfPages}) => {
    return (
        <div className="container-fluid mt-5">
            <div className={`row row-cols-6`}>
                {
                    Brands.length > 0 &&
                    Brands.map((brand, index) => {
                        return (
                            <div className="col-lg-2 d-flex align-items-stretch">
                                <Card 
                                    key={index}
                                    brand={brand}
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