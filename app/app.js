import React, {PropTypes} from "react";
import Header from "./Components/Common/Header";
import Footer from "./Components/Common/Footer";

class App extends React.Component {

    render() {
        return(
            <div className="container-fluid">
                <Header/>
                {this.props.children}
                <Footer/>
            </div>
        );
    }
}


export default App;