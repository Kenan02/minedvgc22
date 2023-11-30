import React, { Component } from 'react';
import Window from './Display';


export class Home extends Component {
  static displayName = Home.name;

  render() {
      return (
          <div>
           <Window/>
        </div>
    );
  }
}
