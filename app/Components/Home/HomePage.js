import React from "react";
import {azurePredictionHub} from "../../Hubs/azurePredictionHub";
import CarPredictionTable from "../Prediction/Cars/CarPredictionTable";
import FlowerPredictionTable from "../Prediction/Flower/FlowerPredictionTable";
import toastr from "toastr";
import toastrOptions from '../Common/toastrOptions';

toastr.options = toastrOptions;

export class HomePage extends React.Component {
    
    constructor(props, context) {
        super(props, context);
        this.state = {
            carPredictions : [],
            flowerPredictions: []
        }

        this.carPredictionCreated = this.carPredictionCreated.bind(this);
        this.flowerPredictionCreated = this.flowerPredictionCreated.bind(this);
    }
    
    componentWillMount(){
        azurePredictionHub.connect().then(() => {
            toastr.success("Conected to real time hub!");
            azurePredictionHub.onCarPredictionCreated(this.carPredictionCreated);
            azurePredictionHub.onFlowerPredictionCreated(this.flowerPredictionCreated);
        });
    }

    carPredictionCreated(prediction) {
        toastr.success("Car prediction created!");
        let predictions = this.state.carPredictions;
        predictions.push(parsePrediction(prediction));
        this.setState({carPredictions: predictions});
    }

    flowerPredictionCreated(prediction){
        toastr.success("Flower prediction created!");
        let predictions = this.state.flowerPredictions;
        predictions.push(parsePrediction(prediction));
        this.setState({flowerPredictions: predictions});  
    }

    render() {
        return (
            <div className="row">
                <div className="col-md-6">
                    <img className="img-responsive center-block bottom-buffer-15" src={require('../../images/car-icon.png')} />
                    <CarPredictionTable predictions = {this.state.carPredictions} />
                </div>
                 <div className="col-md-6">
                     <img className="img-responsive center-block bottom-buffer-15" src={require('../../images/flower-icon.png')} />
                    <FlowerPredictionTable predictions = {this.state.flowerPredictions} />
                </div>
            </div>
        );
    }
}

function parsePrediction(resultData) {
    let parsedData = JSON.parse(resultData);
    return parsedData.Results.output1[0];
}
