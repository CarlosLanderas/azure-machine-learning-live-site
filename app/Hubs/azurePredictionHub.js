
class AzurePredictionHub {
    
    connect() {
        
        this.hub = $.connection.azureMlHub;     

        this.hub.client.notifyCarPredictionCreated = (prediction) => {
            if (this.carSubscriber) {
                this.carSubscriber(prediction);
            }
        };

        this.hub.client.notifyFlowerPredictionCreated = (prediction) => {
            if (this.flowerSubscriber) {
                this.flowerSubscriber(prediction);
            }
        }

        return new Promise((resolve, reject) => {
           $.connection.hub.start({ transport: 'auto' })
           .done(() => {
               console.log("Connection started");
                   resolve();
               });
        });
    }

    onCarPredictionCreated(carPredictionCreatedCallback) {
        this.carSubscriber = carPredictionCreatedCallback;
    }

    onFlowerPredictionCreated(flowerPredictionCreatedCallback){
        this.flowerSubscriber = flowerPredictionCreatedCallback;
    }
}

export let azurePredictionHub = new AzurePredictionHub();