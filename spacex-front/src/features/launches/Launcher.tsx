import { Card, Spin } from 'antd';
import useLaunches from '../../hooks/useLaunches';
import LaunchTable from './LaunchTable';
import SelectApi from './SelectApi';
import SelectData from './SelectData';


function Launcher() {
  
  const{isLoading,data} = useLaunches();



  
  return (
    <Card title="Space X Launches"  >
    
        <SelectApi />
        <SelectData />

    <Spin spinning={isLoading} tip="Loading Please Wait..." >
        <LaunchTable data={data}/>
    </Spin>
  </Card>
    
    
  )
}

export default Launcher