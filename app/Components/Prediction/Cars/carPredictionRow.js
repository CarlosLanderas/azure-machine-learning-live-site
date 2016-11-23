import React, {PropTypes} from 'react';

const CarPredictionRow = ({prediction}) => {

    return(
      <tr>
         <td>{prediction['Scored Labels']}</td>
         <td>{prediction['price']}</td>
        <td>{prediction['highway-mpg']}</td>
        <td>{prediction['make']}</td>
        <td>{prediction['body-style']}</td>       
       </tr>
    );
};

CarPredictionRow.propTypes = {
    prediction: PropTypes.object.isRequired
};

export default CarPredictionRow;