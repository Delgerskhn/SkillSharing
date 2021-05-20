import React from 'react';

import DataGrid,
{
    Column,
    MasterDetail
} from 'devextreme-react/data-grid';

import service from './data.js';
import BlogsDV from './blogs-detailview.js';

const blogs = service.getBlogs();

export default function BlogsLV () {

        return (
            <DataGrid id="grid-container"
                dataSource={blogs}
                keyExpr="pk"
                showBorders={true}
            >
                <Column dataField="title" width={70} caption="Title" />
                {/*<MasterDetail
                    enabled={true}
                    component={BlogsDV}
                />*/}
            </DataGrid>
        );
}

