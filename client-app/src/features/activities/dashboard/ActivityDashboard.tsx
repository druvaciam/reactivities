import { Grid } from "semantic-ui-react";
import ActivityList from "./ActivityList";
import { userStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import ActivityFilters from "./ActivityFilters";

export default observer(function ActivityDashboard() {
    const {activityStore} = userStore();
    const {loadActivities, activityRegistsry} = activityStore;
  
    useEffect(() => {
        if (activityRegistsry.size <= 1)
            loadActivities();
    }, [loadActivities, activityRegistsry.size]);
  
    if (activityStore.loadingInitial)
     return <LoadingComponent content='Loading app...' />

    return (
        <Grid>
            <Grid.Column width='10'>
                <ActivityList />
            </Grid.Column>
            <Grid.Column width='6'>
                <ActivityFilters />
            </Grid.Column>
        </Grid>
    )
})