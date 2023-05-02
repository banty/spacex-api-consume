import { Table } from 'antd';
import { Launch } from './types';
import { Link } from 'react-router-dom';
import { useAppSelector } from '../../app/hooks';
import { selectLauncher } from './LaunchSlice';
import moment from 'moment';

function LaunchTable({data}: {data:Launch[]|undefined}) {
  const {api} =useAppSelector(selectLauncher);
    const columns = [
        
        {
          title: 'Mission Name',
          dataIndex: 'mission_name',
          key: 'mission_name',
          render:(text:number,record:Launch)=><Link to={`/launch/${api==='local'? record._id:  record.flight_number}`}>{text}</Link>

        },
        {
          title: 'Flight Number',
          dataIndex: 'flight_number',
          key: 'flight_number',
        },
        {
          title: 'Launch Year',
          dataIndex: 'launch_year',
          key: 'launch_year',
        },
        {
            title:'Launch Date',
            dataIndex:'launch_date_utc',
            key:'launch_date_utc',
            render: (text:string,)=> <span>{moment(text).format("DD-MM-YYYY HH:mm")}</span>
        }
      ];
  return (
    <>
   
    <Table dataSource={data} columns={columns} rowKey="_id" />
    </>
    
  )
}

export default LaunchTable