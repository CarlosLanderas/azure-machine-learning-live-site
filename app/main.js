import React from 'react';
import {render} from 'react-dom';
import {Router, hashHistory} from 'react-router';
import routes from './routes';
import {HomePage} from './Components/Home/HomePage';
import '../node_modules/toastr/build/toastr.min.css';

render(    
     <Router history={hashHistory} routes={routes} />,
     document.getElementById('app')
);   