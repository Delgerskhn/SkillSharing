import React, { useState } from 'react'
import { constBlog } from '../../utils/constants'
import SelectBox from 'devextreme-react/select-box';

const getStateName =(statePk) => {
    for(let e in Object.entries(constBlog.State)) {
        if(e[1] === statePk) return e[0]
    }
}

export const BlogStatusSelect=(data) =>{
  let States = Object.keys(constBlog.State)
    const [value, setValue] = useState(data.value)
    const onChanged =(val) => {
        console.log(val)
    }

  return <SelectBox items={States} onValueChanged={onChanged}/>
}