<script lang="ts">
    export let status = "Agency";
    let statusClasses = {
        Agency: "bg-emerald-100 text-emerald-900 dark:bg-emerald-700/10 dark:text-emerald-200",
        Freelancer: "bg-blue-100 text-blue-900 dark:bg-blue-700/10 dark:text-blue-200",
        Trial: "bg-orange-100 text-orange-900 dark:bg-orange-700/10 dark:text-orange-200"
    };
</script>

<div class={`inline-flex rounded-full border border-transparent px-2 py-1 text-xs font-semibold leading-4 ${statusClasses[status]}`}>
    {status}
</div>
