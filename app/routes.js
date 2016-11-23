import React from "react";
import  {Route, IndexRoute} from "react-router";
import App from './app';
import {HomePage} from "./Components/Home/HomePage";
import {UploadPage} from "./Components/Upload/UploadPage";

export default (
    <Route path="/" component={App}>
          <IndexRoute component={HomePage} />     
          <Route path="visor" component={HomePage}/>
          <Route path="upload" component={UploadPage}/>
    </Route>
);