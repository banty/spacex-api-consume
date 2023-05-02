import { Carousel } from 'antd'

function MissionGallery({images}:{images: string[] | undefined}) {
  return (
    <div className='p-4 m-4 text-slate-50'>
 <Carousel autoplay>
      {
       images ? images.map(url=>
          <img src={url} className='gallery-image' alt={url} />
          ) :<></>
      }
      </Carousel>
    </div>
   
  )
}

export default MissionGallery