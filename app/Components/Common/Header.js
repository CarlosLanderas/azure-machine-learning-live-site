import React from "react";
import {Link} from "react-router";

const Header = () => {

    return(
        <nav className="navbar navbar-default">            
            <div className="container-fluid">                 
                <div className="navbar-header">
                    <a href="#" className="navbar-brand navbar-link">Azure ML</a>
                    <button data-toggle="collapse" data-target="#navcol-1" className="navbar-toggle collapsed">
                        <span className="sr-only">Toggle navigation</span><span className="icon-bar"></span><span className="icon-bar"></span><span className="icon-bar"></span></button>
                </div>
                <div className="collapse navbar-collapse" id="navcol-1">
                    <ul className="nav navbar-nav">
                        <li className="active">
                         <Link to="visor" className="btn btn-primary btn-lg">Visor</Link>                         
                        </li>  
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Header;
  
