export function populateBlogModel(content, tags) {
    let blog = {
        "Img": getImg(content),
        "Title": getBlock(content, 'heading-one'),
        "Content": JSON.stringify(content),
        "Tags": tags
    }
    return blog
}

function getBlock(content, type) {
    for (let block of content) 
        if (block.type == type)
            return block.children[0].text
    return ''
}

function getImg(content) {
    for (let block of content)
        if (block.type == 'image')
            return block.url
    return ''
}