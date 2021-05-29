import React, { useEffect, useState } from "react";
import { useHistory, withRouter } from "react-router-dom";

import DataGrid, { Column, MasterDetail } from "devextreme-react/data-grid";

import BlogsDV from "./blogs-detailview.js";
import getParam from "../utils/query-string.js";
import { useBlogs } from "../contexts/blog.js";

function imgRender(data) {
  return <img width="150" src={data.value} />;
}

function BlogsLV(props) {
  const {blogs, setBlogsByStatus, setBlogs} = useBlogs()
  const [status, setStatus] = useState(1)
  useEffect(
    () => {
      let p = getParam(props.location.search, "status");
      setBlogsByStatus(p)
      if(p) setStatus(parseInt(p))
    },
    [props.location]
  );
  return (
    <DataGrid
      id="grid-container"
      dataSource={blogs.filter(r=>r.blogStatusPk === status)}
      keyExpr="pk"
      columnAutoWidth={true}
      filter
      wordWrapEnabled
      showBorders={true}
    >
      <Column dataField="title" caption="Title" />
      <Column
        caption="Image"
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
