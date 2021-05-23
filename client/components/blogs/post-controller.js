import React from 'react'
import BorderColorIcon from '@material-ui/icons/BorderColor';
import { Box, Button, ButtonGroup } from '@material-ui/core';
import DeleteIcon from '@material-ui/icons/Delete';
import PublishIcon from '@material-ui/icons/Publish';
import { constBlog } from '../../shared/constants';
import { useRouter } from 'next/router';


export default function PostController({ visible, post }) {
    const router = useRouter()
    const navigateEditor = () => {
        router.push('/editor?pk=' + post.pk)
    }
    const removeBlog = () => {

    }
    const publishBlog = () => {

    }
    return (visible ?
        <Box display="flex" justifyContent="flex-end" flexDirection="row">
        <ButtonGroup>
            {
                !(post?.blogStatusPk == constBlog.State.Published) &&
                <Button onClick={publishBlog}>
                    <PublishIcon fontSize="large" />
                </Button>
            }
                <Button onClick={navigateEditor}>
                <BorderColorIcon style={{fontSize: 30, marginTop: 2}} color="#ba000d" />
            </Button>
                <Button onClick={ removeBlog}>
                <DeleteIcon fontSize="large"/>
            </Button>
        </ButtonGroup>
        </Box> : <div></div>
        )
}