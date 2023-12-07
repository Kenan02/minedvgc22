import React, { useEffect, useState } from "react";

export async function getEmployeeDataById(id) {
    const response = await fetch(id);
    if (!response.ok) {
        throw new Error(response.statusText);
    }
    const data = await response.json();
    return parseEmployeeDataById(data[0]);
}

function parseEmployeeDataById(data) {
    const employee = {
        ID: data.id,
        Name: data.name,
        BirthDate: data.dateOfBirth,
        Gender: data.gender,
        Email: data.email,
        Telephone: data.telephone,
        PrivatePhone: data.privatePhone,
        Street: data.street,
        City: data.city,
        Zip: data.zip,
        EmergencyName: data.emergencyName,
        EmergencyPhoneNumber: data.emergencyPhoneNumber,
        Relationship: data.relationship,
        Street: data.street,
        City: data.city,
        Zip: data.zip,
        Country: data.country,

    };
    console.log(employee);
    return employee;
}


function ListComponentFunction({ id }) {

    const [employeeData, setEmployeeData] = useState({});

    useEffect(() => {
        getEmployeeDataById(id).then((data) => setEmployeeData(data));
    }, [id]);
    
    const renderList = () => {
        if (!employeeData || Object.keys(employeeData).length === 0) {
            return null;
        }
        const keys = Object.keys(employeeData);
        const header = keys[0];
        const items = keys.slice(1).map((key) => ({
            label: key,
            value: employeeData[key],
        }));

        return (
            <div className="list-template">
                {items.map((item) => (
                    <div key={item.label} className="label-template">
                        <strong>{item.label}:</strong> {item.value}
                    </div>
                ))}
            </div>
        );
    };
    return <div>{renderList()}</div>;
}

export default function Window() {

    const [search, setSearch] = useState('');

    const handleSearch = (e) => {
        setSearch(e.target.value);
        console.log(search);
    }

    return (
        <div>
            <input type="text" placeholder="Search.." className='navbar-search' onChange={handleSearch}>
            </input>
            
            <ListComponentFunction id={'/employeeoverview/' + search} />
        </div>

    )



}