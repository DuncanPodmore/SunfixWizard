<script lang="ts">
    import {CheckListStatus} from "../../logic/CheckListLogic";

    export let title: string;
    export let statusText: string;
    export let status: CheckListStatus = CheckListStatus.Good;

    $: statusColor = status === CheckListStatus.Good ? "text-emerald-500" : status === CheckListStatus.Caution? "text-yellow-500" : "text-red-500";
</script>

<li class="flex items-center justify-between p-4">
  <span class="mr-1 text-sm font-semibold">
    {title}
  </span>
  <span class={`text-sm font-medium ${statusColor}`}>
    {statusText}
  </span>
</li>
