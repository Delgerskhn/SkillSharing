import React, { useEffect, useState } from 'react';
import { DataGrid, Column } from 'devextreme-react/data-grid';
import ArrayStore from 'devextreme/data/array_store';
import DataSource from 'devextreme/data/data_source';
import service from './data.js';

const tasks = service.getTasks();

export default function BlogsDV(props)  {
    let { FirstName, LastName } = props.data.data;
    const [dataSource, setDataSource] = useState([])

    useEffect(() => {
        console.log(props.data)
        setDataSource(getTasks(props.data.key));
    }, [])
    
    function completedValue(rowData) {
        return rowData.Status === 'Completed';
    }
    return (
        <React.Fragment>
            <div className="master-detail-caption">
                {`${FirstName} ${LastName}'s Tasks`}
            </div>
            <DataGrid
                dataSource={dataSource}
                showBorders={true}
                columnAutoWidth={true}
            >
                <Column dataField="Subject" />
                <Column dataField="StartDate" dataType="date" />
                <Column dataField="DueDate" dataType="date" />
                <Column dataField="Priority" />
                <Column
                    caption="Completed"
                    dataType="boolean"
                    calculateCellValue={completedValue}
                />
            </DataGrid>
        </React.Fragment>
    );
    
}

function getTasks(key) {
    return new DataSource({
        store: new ArrayStore({
            data: tasks,
            key: 'ID'
        }),
        filter: ['EmployeeID', '=', key]
    });
}

