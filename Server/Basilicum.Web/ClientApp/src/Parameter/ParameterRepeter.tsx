import * as React from 'react';
import Parameter from './Parameter';
import IParameterModel from './ParameterModel';

interface IProps {
    parameters: IParameterModel[];
}

interface IState {
    parameters: IParameterModel[];
}

class ParameterRepeter extends React.Component<IProps, IState>{
    public render() {
        const listItems = this.props.parameters.map((item: IParameterModel) => {
            return (<Parameter parameter={item} key={item.id}/>
            );
        });

        return (
            <div>
                {listItems}
            </div>
        );
    }
}

export default ParameterRepeter;