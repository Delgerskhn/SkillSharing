import React, { useEffect, useState } from 'react';
import { Button } from 'devextreme-react/button';

import Box, {
    Item
  } from 'devextreme-react/box';
  
import BlogEditor from '../components/editor/blog-editor.js';
import { useBlogs } from '../contexts/blog.js';
import { constBlog } from '../utils/constants.js';
 
export default function BlogsDV(props) {
    let { appUser, content, pk } = props.data.data;
    const {updateStatus} = useBlogs()

    const parseContent = () => {
        try {
            return JSON.parse(content)
        }
        catch {
            return []
        }
    }

    const onApprove =() => {
        updateStatus(pk, constBlog.State.Published)
    }

    const onDecline =() => {
        updateStatus(pk, constBlog.State.Declined)
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
                        {`${appUser?.email}'s blog`}
                    </div>
                    <Button 
                        text="Approve" 
                        type="default"                   
                        stylingMode="contained"
                        onClick={onApprove}
                        />
                    <Button 
                        text="Decline" 
                        type="default"                   
                        stylingMode="contained"
                        onClick={onDecline}
                        />
            <BlogEditor readOnly={true} content={parseContent()} />
        </React.Fragment>
    );

}