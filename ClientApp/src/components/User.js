import React, { Component } from 'react';

export class Users extends Component {
    static displayName = Users.name;


    render() { 
        return (
            <form action="/EmployeeController" method="get">
            <div class="form-group">
                    <label for="exampleInputName">Name</label>
                    <input type="text" class="form-control" id="exampleInputName" placeholder="Enter Name" />
   
            </div>
            <div class="form-group">
                    <label for="exampleInputUsername">UserName</label>
                    <input type="text" class="form-control" id="exampleInputUsername" placeholder="Enter username"/>
            </div>
            <div class="form-group">
                    <label for="exampleInputEmail">Email</label>
                    <input type="email" class="form-control" id="exampleInputEmail" placeholder="Enter Email"/>
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
        );
    }

}




