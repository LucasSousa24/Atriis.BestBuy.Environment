const path = require('path')
const HtmlWebpackPlugin = require('html-webpack-plugin')
const { merge } = require('webpack-merge')

const constructCommonConfig = (env) => {
  const environmentValidator = env === "local" ? "dev" : env;
  return {
    entry: path.resolve(__dirname, '..', './src/index.js'),
    resolve: {
      extensions: ['.js', '.jsx'],
    },
    module: {
      rules: [
        {
          test: /\.(js|jsx)$/,
          exclude: /node_modules/,
          use: ['babel-loader'],
        },
        {
          test: /\.css$/,
          use: ['style-loader', 'css-loader'],
        },
        {
          test: /\.(?:ico|gif|png|jpg|jpeg)$/i,
          type: 'asset/resource',
        },
        {
          test: /\.(woff(2)?|eot|ttf|otf|svg|)$/,
          type: 'asset/inline',
        },
      ],
    },
    output: {
      path: path.resolve(__dirname, '..', `./build_${environmentValidator}`),
      filename: 'bundle.js',
    },
    plugins: [
      new HtmlWebpackPlugin({
        template: path.resolve(__dirname, '..', './src/index.html')
      }),
    ],
    stats: 'errors-only',
  };
}

module.exports = ({env}) => {
  const envConfig = require(`./webpack.${env}.js`);
  const commonConfig = constructCommonConfig(env);
  return merge(commonConfig, envConfig);
}