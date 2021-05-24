import React, { useEffect, useState } from 'react';
import { DataGrid, Column } from 'devextreme-react/data-grid';
import ArrayStore from 'devextreme/data/array_store';
import DataSource from 'devextreme/data/data_source';
import service from './data.js';
import BlogEditor from '../components/editor/blog-editor.js';

const tasks = service.getTasks();

export default function BlogsDV(props) {
    let { appUser, content } = props.data.data;

    const parseContent = () => {
        try {
            return JSON.parse(content)
        }
        catch {
            return []
        }
    }

    useEffect(() => {
        console.log(props.data)
    }, [])

    function completedValue(rowData) {
        return rowData.Status === 'Completed';
    }
    return (
        <React.Fragment>
            <div className="master-detail-caption">
                {`${appUser?.email}'s Tasks`}
            </div>
            <BlogEditor readOnly={true} content={parseContent()} />
        </React.Fragment>
    );

}