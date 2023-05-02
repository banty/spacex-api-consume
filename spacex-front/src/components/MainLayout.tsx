import { Layout } from "antd";
import { ReactNode } from "react";

const { Header, Content, Sider } = Layout;

function MainLayout({ children }: { children: ReactNode }) {
  return (
    <Layout>
      <Header className="header">
        <div className="logo" />
      </Header>
      <Layout>
        <Sider width={200}></Sider>
        <Layout style={{ padding: "0 24px 24px" }}>
          <Content
            style={{
              padding: 24,
              margin: 0,
              minHeight: 280,
              //  background: colorBgContainer,
            }}
          >
            {children}
          </Content>
        </Layout>
        <Sider width={200}></Sider>
      </Layout>
    </Layout>
  );
}

export default MainLayout;
