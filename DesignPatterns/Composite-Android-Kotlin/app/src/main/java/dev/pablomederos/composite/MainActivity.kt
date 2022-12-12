package dev.pablomederos.composite

import android.os.Bundle
import android.util.Log
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.Button
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import dev.pablomederos.composite.optionMenu.Option
import dev.pablomederos.composite.optionMenu.OptionGroup
import dev.pablomederos.composite.ui.theme.CompositeTheme

class MainActivity : ComponentActivity() {

    private val selectedElements: MutableSet<String> = mutableSetOf()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)


        val optionGroup = OptionGroup(
            "Group of Group Options", listOf(
                OptionGroup(
                    "Group in gog", listOf(
                        Option("Option 1 in gog", ::onOptionSelected),
                        Option("Option 2 in gog", ::onOptionSelected),
                        Option("Option 3 in gog", ::onOptionSelected)
                    ), ::onOptionSelected
                ),
                Option("Single Option in gog", ::onOptionSelected)
            ), ::onOptionSelected
        )

        setContent {
            CompositeTheme {
                // A surface container using the 'background' color from the theme
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    Row(verticalAlignment = Alignment.CenterVertically) {
                        Button(onClick = {
                            optionGroup.select(true).forEach(selectedElements::add)
                            onOptionSelected(true, listOf())
                        }) {
                            Text(text = "Seleccionar", color = Color.White)
                        }
                        Column {
                            Option("Single Option", ::onOptionSelected).CreateOption()
                            OptionGroup(
                                "Option Group", listOf(
                                    Option("Option 1 in group", ::onOptionSelected),
                                    Option("Option 2 in group", ::onOptionSelected),
                                    Option("Option 3 in group", ::onOptionSelected)
                                ), ::onOptionSelected
                            ).CreateOption()
                            optionGroup.CreateOption()
                        }
                    }
                }
            }
        }
    }

    private fun onOptionSelected(state: Boolean, value: List<String>) {
        if(state)
            value.forEach(selectedElements::add)
        else
            value.forEach(selectedElements::remove)

        Log.i("Selected", "Total de seleccionados: ${selectedElements.size}")
        selectedElements.forEach {Log.i("Selected", it)}

        Log.i("Selected", "----------------------------------")
    }
}