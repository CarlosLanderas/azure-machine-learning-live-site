import React, {PropTypes} from 'react';
import CartPredictionRow from './CarPredictionRow';

const CarPredictionTable = ({predictions}) => {

    return(
       <div className="table-responsive">
        <table className="table">
            <thead>
                <tr>
                    <th className="info">Scored Labels</th>
                    <th className="info">Price</th>
                    <th className="info">highway-mpg</th>
                    <th className="info">Make</th>
                    <th className="info">Body style</th>
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

CarPredictionTable.propTypes = {
    predictions: PropTypes.array.isRequired
};

export default CarPredictionTable;