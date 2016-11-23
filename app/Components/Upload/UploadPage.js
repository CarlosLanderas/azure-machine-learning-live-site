import React from 'react';
import Dropzone from 'react-dropzone';

export class UploadPage extends React.Component {

    constructor(props, context) {
        super(props, context);

        this.state = {
            files: [],
            uploadVisible: false
        }

        this.onDrop = this.onDrop.bind(this);
    }
    onDrop(acceptedFiles, rejectedFiles) {
        let fileLength = acceptedFiles.length;

        this.setState({
            files: acceptedFiles,
            uploadVisible: acceptedFiles.length > 0
        });
    }
    render() {
        return(
            <div className="panel panel-info">
            <div className="panel-heading">
                <h3 className="panel-title">Upload a file for model training</h3></div>
                <div className="panel-body">                     
                    <div className="row">
                     <div className="col-md-12">
                          <Dropzone onDrop={this.onDrop}>
                              <div>Try dropping some files here, or click to select files to upload.</div>
                         </Dropzone>
                     </div>
                    </div>
                    <div className="row">
                      <div className="col-md-12" style= {{ marginTop: "10px" ,display: this.state.uploadVisible ? 'block' : 'none' }}>
                        <input type="button" className="btn btn-success" value="Upload file"/>
                     </div>
                     <div className="col-ms-12">
                         {
                             this.state.files.map (file => {
                                 return <span>{file.name}</span>;
                             })
                         }
                     </div>
                    </div>
                        
                </div>
            </div>
        );
    }
}

