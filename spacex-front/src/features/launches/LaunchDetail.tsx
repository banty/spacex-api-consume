import MissionGallery from './MissionGallery'
import useSpecificLaunches from '../../hooks/useSpecifcLaunch'
import { Link, useParams } from 'react-router-dom';
import DisplayLinks from './Links';
import { Descriptions, Col, Row, Button } from 'antd';
import { LeftOutlined } from '@ant-design/icons';

function LaunchDetail() {
    const {id} = useParams();
    const {isLoading,data,error} =useSpecificLaunches(id)

    if(isLoading) return <h1>Loading ...</h1>

    if(error) return <h1>{"An expected error:" + error}</h1>

  
  return (
    <div>
<div className='default-pad'>
     <Link to="/" className='primary' type='button'><Button type='primary'><LeftOutlined />Back</Button> </Link>
     </div>
    
     <MissionGallery images={data?.links.flickr_images} /> 
     <div className='alternate'>
     <Row gutter={{ xs: 8, sm: 16, md: 24, lg: 32 }} className='default-pad'>
      <Col className="gutter-row" span={6}>
      <a href={data?.links.mission_patch} target='_blank' rel="noreferrer"><img src={data?.links.mission_patch_small} alt="mission patch"/></a> 
      </Col>
      <Col className="gutter-row" span={18}>
       <p className='mission-title'>{data?.mission_name}</p> 
       <p className='mission-description'>
            {data?.details}
        </p>
       

      </Col>
      
    </Row>
    </div>
    
     <div>
     <Descriptions
        bordered
        title="Launch Information"
        size={'small'}
        
      >
        <Descriptions.Item label="Mission Name">{data?.mission_name}</Descriptions.Item>
        <Descriptions.Item label="Flight Number">{data?.flight_number}</Descriptions.Item>
        <Descriptions.Item label="Launch Site">{data?.launch_site.site_name_long}</Descriptions.Item>
        <Descriptions.Item label="Year">{data?.launch_year}</Descriptions.Item>
        <Descriptions.Item label="Success">{data?.launch_success}</Descriptions.Item>
        
        <Descriptions.Item label="Rocker Name">{data?.rocket.rocket_name}</Descriptions.Item>
        <Descriptions.Item label="Description" span={5}>
         {data?.details}
         
        </Descriptions.Item>
        <Descriptions.Item label="Mission Links" span={5}>
        <DisplayLinks links={data?.links}/> 
        </Descriptions.Item>
      </Descriptions>
      
     </div>
    </div>
   
  )
}

export default LaunchDetail