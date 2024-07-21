import React from 'react';

const Card = ({product}) => {
  return (
    <div class="card mb-3" style={{width: "20rem"}} data-bs-theme="dark">
      <img src={product.thumbnailImage} className="card-img-top" alt={product.aiClassification}/>
      <div class="card-body">
        <h5 class="card-title">Product:</h5>
      </div>
      <ul class="list-group list-group-flush">
        <div class="card-body" style={{height: "15rem"}}>
          <h5 class="card-title">Details:</h5>  
          <p class="card-text">{product.name}</p>
          <p class="card-text">Sku - {product.sku}</p>
          <p class="card-text">Price - {product.salePrice}€</p>
        </div>
      </ul>
      <div class="card-body">
        <button type="button" className="btn btn-outline-light">More</button>
      </div>
    </div>
  )
}

export default Card