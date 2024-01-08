import { Button, Container, Menu } from "semantic-ui-react";
import { userStore } from "../stores/store";

export default function NavBar() {
    const {activityStore} = userStore();

    return (
        <Menu inverted fixed="top">
            <Container>
                <Menu.Item header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight: '10px'}} />
                    Reactivities
                </Menu.Item>
                <Menu.Item name="Activities" />
                <Menu.Item>
                    <Button onClick={() => activityStore.openForm()} positive content='Create Activity' />
                </Menu.Item>
            </Container>
        </Menu>
    )
}