import React, {PropTypes} from 'react';
import CartPredictionRow from './FlowerPredictionRow';

const FlowerPredictionTable = ({predictions}) => {

    return(
       <div className="table-responsive">
        <table className="table">
            <thead>
                <tr>
                    <th className="info">Scored Probs</th>
                    <th className="info">Scored Labels</th>
                    <th className="info">Class</th>
                    <th className="info">Sepal length</th>
                    <th className="info">Sepal Width</th>
                    <th className="info">Petal Width</th>
                    <th className="info">Sepal length</th>
                </tr>
            </thead>
            <tbody>
                {
                    predictions.map( prediction=> 
                        <CartPredictionRow key={Math.random()} prediction={prediction} />
                    )}
                
            </tbody>
        </table>
       </div>
    );
};

    FlowerPredictionTable.propTypes = {
    predictions: PropTypes.array.isRequired
};

export default FlowerPredictionTable;