import { Box } from "@material-ui/core"
import FeaturedPost from "./FeaturedPost"

function withController(Post) {
    return function WrappedPost() {

        return (
            <Box>
                <Post />
            </Box>
            )
    }
}

const PostWithController = withController(FeaturedPost)

export { PostWithController }