import React, { useEffect, useState } from "react";
import { useHistory, withRouter } from "react-router-dom";

import DataGrid, { Column, MasterDetail } from "devextreme-react/data-grid";

import BlogsDV from "./blogs-detailview.js";
import getParam from "../utils/query-string.js";
import { getBlogs } from "./data.js";

function imgRender(data) {
  return <img width="150" src={data.value} />;
}

function BlogsLV(props) {
  const [blogs, setBlogs] = useState([]);
  useEffect(
    () => {
      let p = getParam(props.location.search, "status");
      setBlogs(getBlogs(p));
    },
    [props.location]
  );
  return (
    <DataGrid
      id="grid-container"
      dataSource={blogs}
      keyExpr="pk"
      columnAutoWidth={true}
      wordWrapEnabled
      showBorders={true}
    >
      <Column dataField="title" caption="Title" />
      <Column
        dataField="Image"
        dataField="img"
        allowSorting={false}
        cellRender={imgRender}
      />
      <Column dataField="description" caption="Description" width="300" />
      <Column dataField="likes" caption="Likes" dataType="number" />
      <Column dataField="createdOn" caption="Created" dataType="date" />
      <Column dataField="appUser.email" caption="Writer" />
      <Column dataField="appUser.reputation" caption="Writer Reputation" />
      <MasterDetail
        enabled={true}
        component={BlogsDV}
      />
    </DataGrid>
  );
}

export default withRouter(BlogsLV);
