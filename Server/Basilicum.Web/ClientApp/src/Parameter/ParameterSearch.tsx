import * as React from 'react';
import ParameterRepeter from './ParameterRepeter';

class ParameterSearch extends React.Component{
    public render() {
        return (
          <div>
              <input placeholder="Search for..."/>
              <ParameterRepeter/>
          </div>
        );
      }
}

export default ParameterSearch;