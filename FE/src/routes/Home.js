import React from 'react';

const Home = () => {
  return (
    <>
      <body>
        <div class="container">
          <div class="row justify-content-center">
            <div class="col-md-8">
              <div class="intro-text text-center">
                <h1 class="mb-4">Welcome to Atriis Best Buy</h1>
                <p class="lead">This SPA displays a list of products. The list should includes the SKU, name, price, and a thumbnail image of the product.</p>
                <p>The list is filterable by name and product category and sortable by name and price.</p>
                <p>Clicking on an item displays the same information and a larger image of the product.</p>
                <p>Navigating between the list and the product information page doesn't change the selected filters orsorted orders.</p>
                <p>The selected filters sort order are stored in the backend and re-applied if a user returns to the application.</p>
                <p>The frontend only uses API requests to communicate with the backend and only with its own backend.</p>
              </div>
              <div class="d-flex justify-content-center">
                <img src="https://corporate.bestbuy.com/wp-content/uploads/2017/03/best-buy-logo.jpg" alt="Best Buy logo" class="rounded-img"/>
                <img src="https://media.licdn.com/dms/image/sync/D4E27AQGd2RPm-ww_1w/articleshare-shrink_800/0/1711982541432?e=2147483647&v=beta&t=arng6YuS32DeYbN-YkOzCeMc_ovfbPAy5fQzJ1eJUXg" alt="Atriis logo" class="rounded-img"/></div>
            </div>
          </div>
        </div>
      </body>
    </>
  )
}

export default Home
