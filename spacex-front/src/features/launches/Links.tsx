import React from 'react'
import { Links } from './types'

function DisplayLinks({links}: {links:Links | undefined} ) {
    if(!links) return <></>
  return (
    <div className='text-left'>

        <div><a href={links.reddit_campaign}>Mission Campaign</a></div>
        <div><a href={links.article_link}>Mission Article</a></div>
        <div><a href={links.mission_patch}>Mission patch</a></div>
        <div><a href={links.mission_patch_small}>Mission small patch</a></div>
        <div><a href={links.presskit}>Press</a></div>
        <div><a href={links.reddit_launch}>Launch</a></div>
        <div><a href={links.reddit_media}>Media</a></div>
        <div><a href={links.reddit_recovery}>Recovery</a></div>
        <div><a href={links.video_link}>Video Link</a></div>
        <div><a href={links.wikipedia}>Wikipedia</a></div>
        <div><a href={links.youtube_id}>Youtube</a></div>

       
    </div>
    
  )
}

export default DisplayLinks