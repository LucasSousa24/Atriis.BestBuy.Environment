import React from 'react';

const Card = ({brand}) => {

  const CleanClassification = (classification) => {
    if (!classification) return "Failed Detection";

    if(classification.length > 258){
      return `${classification.substring(0,257)}...`;
    }
    return classification;
}

  return (
    <div class="card mb-3" style={{width: "20rem"}} data-bs-theme="dark">
      <img src={brand.url} className="card-img-top" alt={brand.aiClassification}/>
      <div class="card-body">
        <h5 class="card-title">Article Brand:</h5>
        <p class="card-text">{brand.articleBrand}</p>
      </div>
      <ul class="list-group list-group-flush">
        <div class="card-body" style={{height: "15rem"}}>
          <h5 class="card-title">AI Classification:</h5>  
          <p class="card-text">Brand Detected - {CleanClassification(brand.aiClassification)}</p>
        </div>
        <div class="card-body">
          <p class="card-text">Classified at {CleanClassification(brand.aiClassificationDate)}</p>
        </div>
      </ul>
      <ul class="list-group list-group-flush">
        <div class="card-body" style={{height: "6rem"}}>
          <h5 class="card-title">Training Classification:</h5>  
          <p class="card-text">Brand Detected - {CleanClassification(brand.trainingClassification)}</p>
        </div>
        <div class="card-body">
          <p class="card-text">Classified at {CleanClassification(brand.trainingClassificationDate)}</p>
        </div>
      </ul>
      <div class="card-body">
        <button type="button" className="btn btn-outline-light"  onClick={() => window.open(brand.articleUrl)}>Article</button>
      </div>
    </div>
  )
}

export default Card