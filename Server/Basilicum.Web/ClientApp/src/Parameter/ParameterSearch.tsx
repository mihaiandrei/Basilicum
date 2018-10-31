import * as React from 'react';
import IParameterModel from './ParameterModel';
import ParameterRepeter from './ParameterRepeter';

interface IProps {
    parameter: string;
}

interface IState {
    parameter: string;
}

class ParameterSearch extends React.Component<IProps, IState>{

    public render() {
        const items: IParameterModel[] = [
            { name: 'Matthew' },
            { name: 'Mark' },
            { name: 'Luke' },
            { name: 'John' }
        ];

        return (
            <div>
                <input placeholder="Search for..." />
                <ParameterRepeter parameters={items}/>
            </div>
        );
    }
}

export default ParameterSearch;