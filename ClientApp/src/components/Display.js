﻿import React, { useEffect, useState } from "react";

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
        Name: data.name,
        Telephone: data.telephone,
        Position: data.position,
        Department: data.department,
        Email: data.email,
        StartDate: data.startDate,
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


    return (
        <div>
            <ListComponentFunction id={'/employeeoverview'} />
        </div>

    )



}