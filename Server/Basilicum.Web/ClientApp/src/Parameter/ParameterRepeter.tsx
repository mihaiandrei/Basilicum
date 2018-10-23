import * as React from 'react';
import Parameter from './Parameter';

class ParameterRepeter extends React.Component{
    public render() {
        return (
          <div>
              <Parameter Name="Humidity"/>
              <Parameter Name="Temperature"/>
          </div>
        );
      }
}

export default ParameterRepeter;