<script lang="ts">
    import ProjectList from './MenuList.svelte';
    import AddNewList from './AddNewMenuList.svelte';

    let lists = [
        { title: 'Work', color: 'rose', cards: [
                { title: 'Project Update', color: 'rose' },
                { title: 'New Post', color: 'emerald' },
                { title: 'Social Marketing', color: 'amber', views: true, comments: 4 },
                { title: 'Logo Design', color: 'emerald' }
            ]},
        { title: 'Travel', color: 'sky', cards: [
                { title: 'Photography Trip', color: 'sky', location: true, users: true, comments: 6 },
                { title: 'Iceland Roadtrip', color: 'sky', location: true, comments: 3 }
            ]},
        { title: 'Personal', color: 'indigo', cards: [
                { title: 'Groceries', color: 'indigo', users: true, comments: 5 },
                { title: 'Tech', color: 'indigo', users: true, comments: 6 }
            ]}
    ];
</script>

<div class="grid grid-cols-1 items-start gap-4 lg:grid-cols-4 dark:text-gray-100">
    {#each lists as list}
        <ProjectList {list} />
    {/each}
    <AddNewList />
</div>
