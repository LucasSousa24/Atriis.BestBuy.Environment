# Project Title
WDH Hackathon Portal

## Links:
* Access the site in the development environment [wdh-hackathon-portal.dev-usa-gke.int.cision.com](https://wdh-hackathon-portal.dev-usa-gke.int.cision.com)

## Table of Content:
- [About The App](#about-the-app)
- [Technologies](#technologies)
- [Setup](#setup)
- [Status](#status)

## About The App
WDH-Hackathon-Portal is an React application created with the solo purpose being the hackathon.

## Technologies
* [React](https://react.dev/blog/2022/03/29/react-v18)
* [Webpack](https://webpack.js.org/)
* [Babel](https://babeljs.io/docs/)
* [NGIX](https://www.nginx.com/)

## Setup
- Download or clone the repository
- Run `npm i`
- To run with a local backed api execute the `npm start` command
- To run with the development backed api execute the `npm run build:dev` command, and the `cd build_dev` followed by the `npx serve` command
- When executing the deployment certify that the build_dev and build_prod packages are up to date with the new implementations

## Status
[WDH-Hackathon-Portal]