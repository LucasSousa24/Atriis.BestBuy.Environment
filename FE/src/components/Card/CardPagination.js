import { FaArrowCircleLeft, FaArrowCircleRight } from "react-icons/fa";

const CardPagination = ({printableBtns, pageAt, alterPage, maxNumberOfPages}) => {
    return (
        <div className="btn-group mt-5 mb-5" role="group">
            <button type="button" className="btn btn-dark pr-1 btn-lg" onClick={() => alterPage(Math.min(...printableBtns) - 1 === 0 ? 1 : Math.min(...printableBtns) - 1)}>
                <FaArrowCircleLeft/>
            </button>
            {
                printableBtns.map((buttonNumber) => {
                    if (buttonNumber === pageAt) {
                        return <button type="button" key={buttonNumber} className="btn btn-dark pr-1 btn-lg">{buttonNumber}</button>
                    } else {
                        return <button type="button" key={buttonNumber} className="btn btn-outline-dark pr-1 btn-lg" onClick={() => alterPage(buttonNumber)}>{buttonNumber}</button>
                    }    
                })
            }
            <button type="button" className="btn btn-dark pr-1 btn-lg" onClick={() => alterPage(Math.max(...printableBtns) + 1 < maxNumberOfPages ? Math.max(...printableBtns) + 1 : pageAt)}>
                <FaArrowCircleRight/>
            </button>
        </div>
    )
}

export default CardPagination
