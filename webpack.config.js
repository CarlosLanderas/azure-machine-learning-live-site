var path = require('path');
var webpack = require('webpack');

var ROOT_PATH = path.resolve(__dirname);

module.exports = {
    entry: {
        app: './app/main'
    },
    output: {
        path: 'wwwroot/dist',
        filename: '[name].bundle.js',
        publicPath: 'dist'
    },
    devtool: 'eval-source-map',
    resolve: {
        alias: {
            "bootstrap": path.resolve(__dirname, 'wwwroot', 'scripts')
        },
        extensions: ['', '.js']
    },
    module: {
        loaders: [           
           { test: /\.js$/, loader: 'babel', exclude: path.resolve(__dirname, "node_modules") },
           { test: /(\.css)$/, loaders: ['style', 'css'] },
           { test: /\.(png|jpg)$/, loader: 'file-loader?name=/images/[name].[ext]' },
        ]
    },
    externals: {     
        "jquery": "jQuery"
    }
};