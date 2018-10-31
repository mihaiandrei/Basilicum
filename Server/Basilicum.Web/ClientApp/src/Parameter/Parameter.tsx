import * as React from 'react';
import IParameterModel  from './ParameterModel';

interface IProps{
    parameter: IParameterModel;
}

class Parameter extends React.Component<IProps>{
    public render() {
        return (
          <div>
            <p>{this.props.parameter.name}</p>
          </div>
        );
      }
}

export default Parameter;