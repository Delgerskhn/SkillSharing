import React, { useEffect, useState } from "react";
import { useHistory, withRouter } from "react-router-dom";
import { getAuthors } from '../api/authors';

import DataGrid, { Column } from "devextreme-react/data-grid";


function imgRender(data) {
  return <img width="150" src={data.value} />;
}

function AuthorsLV(props) {
    const [authors, setAuthors] = useState([])
    useEffect(()=>{
        (async ()=>{
            let res = await getAuthors()
            setAuthors(res)
        })()
    },[])
  return (
    <DataGrid
      id="grid-container"
      dataSource={authors}
      keyExpr="id"
      columnAutoWidth={true}
      filter
      wordWrapEnabled
      showBorders={true}
    >
      <Column dataField="firstName" caption="First name" />
      <Column dataField="lastName" caption="Last name" />
      <Column dataField="email" caption="Email" />
      <Column dataField="reputation" caption="Reputation" />
      <Column dataField="withdrawReputation" caption="Withdraw reputation" />
    </DataGrid>
  );
}

export default withRouter(AuthorsLV);
