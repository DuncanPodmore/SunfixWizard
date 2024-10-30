<script lang="ts">
    export let tableName = "";
</script>

<!-- Tables: With Heading and Action -->
<div
        class="mb-5 flex flex-col gap-3 text-center sm:flex-row sm:items-center sm:justify-between sm:text-left"
>
    <div>
        <h3 class="mb-1 font-semibold">{tableName}s</h3>
        <h4 class="text-sm font-medium text-gray-500 dark:text-gray-400">
            You have
            <a
                    href="javascript:void(0)"
                    class="text-blue-600 hover:text-blue-400 dark:text-blue-400 dark:hover:text-blue-300"
            >5 user accounts</a
            >
        </h4>
    </div>
    <div class="flex items-center justify-center gap-2">
        <button
                type="button"
                class="inline-flex items-center justify-center gap-2 rounded-lg border border-blue-700 bg-blue-700 px-3 py-2 text-sm font-semibold leading-5 text-white hover:border-blue-600 hover:bg-blue-600 hover:text-white focus:ring focus:ring-blue-400/50 active:border-blue-700 active:bg-blue-700 dark:focus:ring-blue-400/90"
        >
            Add new {tableName.toLocaleLowerCase()}
        </button>
    </div>
</div>

<!-- Responsive Table Container -->
<div
        class="min-w-full overflow-x-auto rounded border border-gray-200 bg-white dark:border-gray-700 dark:bg-gray-800"
>
    <!-- Table -->
    <table class="min-w-full whitespace-nowrap align-middle text-sm">
        <!-- Table Header -->
        <thead>
        <tr>
            <th
                    class="bg-gray-100/75 px-3 py-4 text-left font-semibold text-gray-900 dark:bg-gray-700/25 dark:text-gray-50"
            >
                Name
            </th>
            <th
                    class="bg-gray-100/75 px-3 py-4 text-left font-semibold text-gray-900 dark:bg-gray-700/25 dark:text-gray-50"
            >
                Email
            </th>
            <th
                    class="bg-gray-100/75 px-3 py-4 text-left font-semibold text-gray-900 dark:bg-gray-700/25 dark:text-gray-50"
            >
                Plan
            </th>
            <th
                    class="bg-gray-100/75 px-3 py-4 text-right font-semibold text-gray-900 dark:bg-gray-700/25 dark:text-gray-50"
            >
                MMR
            </th>
            <th
                    class="bg-gray-100/75 px-3 py-4 text-center font-semibold text-gray-900 dark:bg-gray-700/25 dark:text-gray-50"
            >
                Actions
            </th>
        </tr>
        </thead>
        <!-- END Table Header -->

        <!-- Table Body -->
        <tbody>
        <tr class="even:bg-gray-50 dark:even:bg-gray-900/50">
            <td class="p-3">
                <p class="font-medium">Nansi Hart</p>
            </td>
            <td class="p-3 text-gray-500 dark:text-gray-400">n.hart@example.com</td>
            <td class="p-3">
                <div
                        class="inline-flex rounded-full border border-transparent bg-emerald-100 px-2 py-1 text-xs font-semibold leading-4 text-emerald-900 dark:border-emerald-900 dark:bg-emerald-700/10 dark:font-medium dark:text-emerald-200"
                >
                    Agency
                </div>
            </td>
            <td class="p-3 text-right">$49,00</td>
            <td class="p-3 text-center">
                <button
                        type="button"
                        class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white px-2 py-1 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300/25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600/40 dark:active:border-gray-700"
                >
                    Edit
                </button>
            </td>
        </tr>
        <tr class="even:bg-gray-50 dark:even:bg-gray-900/50">
            <td class="p-3">
                <p class="font-medium">Lia Baker</p>
            </td>
            <td class="p-3 text-gray-500 dark:text-gray-400">
                l.baker@example.com
            </td>
            <td class="p-3">
                <div
                        class="inline-flex rounded-full border border-transparent bg-blue-100 px-2 py-1 text-xs font-semibold leading-4 text-blue-900 dark:border-blue-900/75 dark:bg-blue-700/10 dark:font-medium dark:text-blue-200"
                >
                    Freelancer
                </div>
            </td>
            <td class="p-3 text-right">$19,00</td>
            <td class="p-3 text-center">
                <button
                        type="button"
                        class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white px-2 py-1 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300/25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600/40 dark:active:border-gray-700"
                >
                    Edit
                </button>
            </td>
        </tr>
        <tr class="even:bg-gray-50 dark:even:bg-gray-900/50">
            <td class="p-3">
                <p class="font-medium">Xavier Rosales</p>
            </td>
            <td class="p-3 text-gray-500 dark:text-gray-400">
                x.rosales@example.com
            </td>
            <td class="p-3">
                <div
                        class="inline-flex rounded-full border border-transparent bg-orange-100 px-2 py-1 text-xs font-semibold leading-4 text-orange-900 dark:border-orange-900/75 dark:bg-orange-700/10 dark:font-medium dark:text-orange-200"
                >
                    Trial
                </div>
            </td>
            <td class="p-3 text-right">$0,00</td>
            <td class="p-3 text-center">
                <button
                        type="button"
                        class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white px-2 py-1 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300/25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600/40 dark:active:border-gray-700"
                >
                    Edit
                </button>
            </td>
        </tr>
        <tr class="even:bg-gray-50 dark:even:bg-gray-900/50">
            <td class="p-3">
                <p class="font-medium">Danyal Clark</p>
            </td>
            <td class="p-3 text-gray-500 dark:text-gray-400">
                d.clark@example.com
            </td>
            <td class="p-3">
                <div
                        class="inline-flex rounded-full border border-transparent bg-emerald-100 px-2 py-1 text-xs font-semibold leading-4 text-emerald-900 dark:border-emerald-900 dark:bg-emerald-700/10 dark:font-medium dark:text-emerald-200"
                >
                    Agency
                </div>
            </td>
            <td class="p-3 text-right">$49,00</td>
            <td class="p-3 text-center">
                <button
                        type="button"
                        class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white px-2 py-1 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300/25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600/40 dark:active:border-gray-700"
                >
                    Edit
                </button>
            </td>
        </tr>
        <tr class="even:bg-gray-50 dark:even:bg-gray-900/50">
            <td class="p-3">
                <p class="font-medium">Keira Simons</p>
            </td>
            <td class="p-3 text-gray-500 dark:text-gray-400">
                k.simons@example.com
            </td>
            <td class="p-3">
                <div
                        class="inline-flex rounded-full border border-transparent bg-blue-100 px-2 py-1 text-xs font-semibold leading-4 text-blue-900 dark:border-blue-900/75 dark:bg-blue-700/10 dark:font-medium dark:text-blue-200"
                >
                    Freelancer
                </div>
            </td>
            <td class="p-3 text-right">$19,00</td>
            <td class="p-3 text-center">
                <button
                        type="button"
                        class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white px-2 py-1 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300/25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600/40 dark:active:border-gray-700"
                >
                    Edit
                </button>
            </td>
        </tr>
        </tbody>
        <!-- END Table Body -->
    </table>
    <!-- END Table -->
</div>
<!-- END Responsive Table Container -->
<!-- END Tables: With Heading and Action -->
