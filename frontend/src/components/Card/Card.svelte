<script>
    export let title = '';
    export let blurb = '';
</script>

<!-- Cards: Simple -->
<div
        class="flex flex-col overflow-hidden rounded-lg bg-white shadow-sm dark:bg-gray-800 dark:text-gray-100"
>
    <!-- Card Header -->
    <div class="bg-gray-50 px-5 py-4 dark:bg-gray-700/50">
        <h3 class="font-medium">{title}</h3>
    </div>
    <!-- END Card Header -->

    <!-- Card Body -->
    <div class="grow p-5">
        <p>{blurb}</p>
    </div>
    <!-- END Card Body -->
</div>
<!-- END Cards: Simple -->
