const { EnvironmentPlugin } = require('webpack');

module.exports = {
  mode: 'development',
  devtool: 'source-map',
  devServer: {
    historyApiFallback: true,
  },
  output: {
    publicPath: '/',
  },
  plugins: [
    new EnvironmentPlugin({
      API: "https://brand-detection.dev-usa-gke.int.cision.com",
    })
  ],
}