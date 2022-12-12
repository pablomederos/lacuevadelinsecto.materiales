package dev.pablomederos.composite.optionMenu

import androidx.compose.ui.Alignment
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Checkbox
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableStateOf
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.unit.Dp

class Option(
    private val name: String,
    private val callback: (state: Boolean, value: List<String>) -> Unit
) : IOption {

    private val isChecked = mutableStateOf(false)

    @Composable
    override fun CreateOption() {
        Row(
            modifier = Modifier
                .border(width = Dp(2f), color = Color.Green)
                .padding(Dp(5f)),
            verticalAlignment = Alignment.CenterVertically
        ) {
            Checkbox(isChecked.value, onCheckedChange = { checkboxState ->
                callback(
                    checkboxState,
                    select(checkboxState)
                )
            })
            Text(text = name)
        }
    }

    override fun select(state: Boolean): List<String> {
        isChecked.value = state
        return listOf(name)
    }

}
