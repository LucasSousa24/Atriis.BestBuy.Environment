const { EnvironmentPlugin } = require('webpack')
const ReactRefreshWebpackPlugin = require('@pmmmwh/react-refresh-webpack-plugin')

module.exports = {
  mode: 'development',
  devtool: 'cheap-module-source-map',
  devServer: {
    hot: true,
    open: true,
    historyApiFallback: true
  },
  output: {
    publicPath: '/'
  },
  plugins: [
    new ReactRefreshWebpackPlugin(),
    new EnvironmentPlugin({
      API: "http://localhost:7192",
    }),
  ],
}