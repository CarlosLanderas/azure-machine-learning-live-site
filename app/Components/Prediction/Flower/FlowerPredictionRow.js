import React, {PropTypes} from 'react';

const FlowerPredictionRow = ({prediction}) => {

    return(
      <tr>
        <td>{prediction['Scored Probabilities']}</td>
        <td>{prediction['Scored Labels']}</td>
        <td>{prediction.class}</td>
        <td>{prediction.sepallength}</td>
        <td>{prediction.sepalwidth}</td>
        <td>{prediction.petallength}</td>
        <td>{prediction.petalwidth}</td>
       </tr>
    );
};

FlowerPredictionRow.propTypes = {
    prediction: PropTypes.object.isRequired
};

export default FlowerPredictionRow;